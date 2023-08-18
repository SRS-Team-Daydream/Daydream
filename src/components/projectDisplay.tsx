import "../styles/projectDisplay.css";

interface Props {
  name: string;
  description: string;
  capabilities: [string, (string | undefined)?][] | undefined;
}

function ProjectDisplay({ name, description, capabilities }: Props) {
  return (
    <div className="projectDisplay">
      <p className="projectName">{name}</p>
      <p className="projectDescription">{description}</p>
      {capabilities ? (
        <>
          {" "}
          <p className="capabilities">capabilities:</p>
          <div className="capabilityList">
            {capabilities.map((item) => {
              return (
                <li className="projectCapability">
                  <p className="capabilityDescription">{item[0]}</p>
                  <img className="image" src={item[1]} />
                </li>
              );
            })}
          </div>
        </>
      ) : null}
    </div>
  );
}

export default ProjectDisplay;
