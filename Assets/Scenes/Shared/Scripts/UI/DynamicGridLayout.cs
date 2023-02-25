using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Daydream
{
    public class GridSiblings
    {
        public Transform Right, Up, Left, Down;
    }

    public class DynamicGridLayout : LayoutGroup
    {
        [SerializeField] int _columns;

        [SerializeField] Vector2 _spacing = Vector2.zero;

        [Tooltip("Width to height ratio")]
        [SerializeField] float _aspect = 1.0f;

        public int Columns => _columns;
        public Vector2 Spacing => _spacing;

        public float Aspect => _aspect;

        public Vector2 MinCellSize => CellSizeFromWidth(minWidth);
        public Vector2 PreferredCellSize => CellSizeFromWidth(preferredWidth);

        public Transform GetChild(int x, int y)
            => y * _columns + x < transform.childCount 
            && x > 0 && y > 0 && x < _columns
                ? transform.GetChild(y * _columns + x) 
                : null;

        public Vector2Int GetChildGridCoordinate(Transform child)
            => new Vector2Int(
                child.GetSiblingIndex() % _columns,
                child.GetSiblingIndex() / _columns
            );

        public GridSiblings GetChildSiblings(Transform child)
        {
            Vector2Int coord = GetChildGridCoordinate(child);
            return new GridSiblings
            {
                Right = GetChild(coord.x + 1, coord.y),
                Left = GetChild(coord.x - 1, coord.y),
                Up = GetChild(coord.x, coord.y - 1),
                Down = GetChild(coord.x, coord.y + 1),
            };
        }

        Vector2 CellSizeFromWidth(float width)
        {
            // padding + (width + spacing) * _columns - spacing = minWidth
            // width = (minWidth - padding + spacing)/_columns - spacing
            float cellWidth = (width - padding.horizontal + _spacing.x) / _columns - _spacing.x;
            return new Vector2(cellWidth, cellWidth / _aspect);
        }

        public override void CalculateLayoutInputVertical()
        {
            SetLayoutInputForAxis(
                padding.vertical,
                padding.vertical,
                -1, // no flex 
                0 // horizontal
            );
        }

        public override void CalculateLayoutInputHorizontal()
        {
            base.CalculateLayoutInputHorizontal();

            SetLayoutInputForAxis(
                padding.horizontal + (MinCellSize.x + _spacing.x) * _columns - _spacing.x,
                padding.horizontal + (PreferredCellSize.x + _spacing.x) * _columns - _spacing.x,
                -1, // no flex 
                0 // horizontal
            );
        }

        public override void SetLayoutHorizontal()
        {
            SetCellsAlongAxis(0);
        }

        public override void SetLayoutVertical()
        {
            SetCellsAlongAxis(1);
        }

        private void SetCellsAlongAxis(int axis)
        {
            float width = rectTransform.rect.size.x;
            float height = rectTransform.rect.size.y;

            Vector2 cellSize = CellSizeFromWidth(width);

            // Normally a Layout Controller should only set horizontal values when invoked for the horizontal axis
            // and only vertical values when invoked for the vertical axis.
            // However, in this case we set both the horizontal and vertical position when invoked for the vertical axis.
            // Since we only set the horizontal position and not the size, it shouldn't affect children's layout,
            // and thus shouldn't break the rule that all horizontal layout must be calculated before all vertical layout.
            var rectChildrenCount = rectChildren.Count;
            if (axis == 0)
            {
                // Only set the sizes when invoked for horizontal axis, not the positions.

                for (int i = 0; i < rectChildrenCount; i++)
                {
                    RectTransform rect = rectChildren[i];

                    m_Tracker.Add(this, rect,
                        DrivenTransformProperties.Anchors |
                        DrivenTransformProperties.AnchoredPosition |
                        DrivenTransformProperties.SizeDelta);

                    rect.anchorMin = Vector2.up;
                    rect.anchorMax = Vector2.up;
                    rect.sizeDelta = cellSize;
                }
                return;
            }

            int cellCountX = 1;
            int cellCountY = 1;
            
            cellCountX = _columns;

            if (rectChildrenCount > cellCountX)
                cellCountY = rectChildrenCount / cellCountX + (rectChildrenCount % cellCountX > 0 ? 1 : 0);

            int cellsPerMainAxis, actualCellCountX, actualCellCountY;

            cellsPerMainAxis = cellCountX;
            actualCellCountX = Mathf.Clamp(cellCountX, 1, rectChildrenCount);

             actualCellCountY = Mathf.Clamp(cellCountY, 1, Mathf.CeilToInt(rectChildrenCount / (float)cellsPerMainAxis));

            Vector2 requiredSpace = new Vector2(
                actualCellCountX * cellSize.x + (actualCellCountX - 1) * _spacing.x,
                actualCellCountY * cellSize.y + (actualCellCountY - 1) * _spacing.y
            );
            Vector2 startOffset = new Vector2(
                GetStartOffset(0, requiredSpace.x),
                GetStartOffset(1, requiredSpace.y)
            );

            // Fixes case 1345471 - Makes sure the constraint column / row amount is always respected
            int childrenToMove = 0;
            if (rectChildrenCount > _columns && Mathf.CeilToInt((float)rectChildrenCount / (float)cellsPerMainAxis) < _columns)
            {
                childrenToMove = _columns - Mathf.CeilToInt((float)rectChildrenCount / (float)cellsPerMainAxis);
                childrenToMove += Mathf.FloorToInt((float)childrenToMove / ((float)cellsPerMainAxis - 1));
                if (rectChildrenCount % cellsPerMainAxis == 1)
                    childrenToMove += 1;
            }

            for (int i = 0; i < rectChildrenCount; i++)
            {
                int positionX;
                int positionY;

                positionX = i % cellsPerMainAxis;
                positionY = i / cellsPerMainAxis;
                
                SetChildAlongAxis(rectChildren[i], 0, startOffset.x + (cellSize[0] + _spacing[0]) * positionX, cellSize[0]);
                SetChildAlongAxis(rectChildren[i], 1, startOffset.y + (cellSize[1] + _spacing[1]) * positionY, cellSize[1]);
            }
        }
    }
}
