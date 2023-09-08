import "../styles/Navbar.css";

interface Props {
  theme: string;
  handleClick: () => void;
}

function Navbar({ theme, handleClick }: Props) {
  return (
    <div className="navbar-container">
      <div className="left-side" />
      <nav className="nav">
        <ul>
          <li>
            <a href="/">Home</a>
          </li>
          <li>
            <a href="/about/">About Me</a>
          </li>
          <li>
            <a href="/skills/">Skills/Projects</a>
          </li>
          <li>
            <a href="/resources/">Resources</a>
          </li>
          <li>
            <a href="/contact/">Contact</a>
          </li>
        </ul>
      </nav>
      <div className="right-side">
        <button onClick={handleClick}>
          Switch to {theme === "light" ? "Dark" : "Light"} Theme
        </button>
      </div>
    </div>
  );
}

export default Navbar;
