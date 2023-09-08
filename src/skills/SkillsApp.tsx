import Navbar from "../components/Navbar.js";
import { createContext } from "react";
import useLocalStorage from "use-local-storage";
import "../styles/App.css";
import "bootstrap/dist/css/bootstrap.css";
import Skills from "../components/Skills.tsx";


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
        <div className="Left"></div>
        <div className="Middle"> <Skills/></div>
        <div className="Right"></div>
      </div>
    </div>
  );
}

export default App;
