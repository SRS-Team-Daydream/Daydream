import Navbar from "../components/Navbar.js";
import { createContext } from "react";
import useLocalStorage from "use-local-storage";
import "../styles/App.css";
import "bootstrap/dist/css/bootstrap.css";
import Resources from "../components/Resources.tsx";


export const ThemeContext = createContext("light");

function App() {
  const defaultDark = window.matchMedia("(prefers-color-scheme: dark)").matches;
  const [theme, setTheme] = useLocalStorage(
    "theme",
    defaultDark ? "dark" : "light"
  );

  const switchTheme = () => {
    const newTheme = theme === "light" ? "dark" : "light";
    setTheme(newTheme);
  };


  return (
    <div className="app" data-theme={theme}>
      <div className="top-container">
        <Navbar theme={theme} handleClick={switchTheme} />
      </div>
      <div className="main">
        <div className="AltLeft"></div>
        <div className="Middle"> <Resources/></div>
        <div className="AltRight"></div>
        <div className="bottomEdge layer"></div>
      </div>
    </div>
  );
}

export default App;
