import "../styles/Skills.css";
import ProjectDisplay from "./projectDisplay";

function Skills() {
  let skills: [string, string][] = [
    ["HTML", "/assets/HTML.png"],
    ["CSS", "/assets/CSS.png"],
    ["Python", "/assets/Python.png"],
    ["C++", "/assets/C++.png"],
    ["C#", "/assets/Csharp.png"],
    ["Unity", "/assets/Unity.png"],
    ["Javascript", "/assets/Javascript.png"],
    ["React", "/assets/React.png"],
    ["Typescript", "/assets/Typescript.png"],
    ["Node", "/assets/node.png"],
    ["Matlab", "/assets/Matlab.png"],
    ["MySQL", "/assets/SQL.png"],
  ];
  let projects: [string, string, [string, string?][]?][] = [
    [
      "MyPasswordManager",
      "A simplistic accounts manager that needs no access to the internet written in Python. Like most people I did not want the hassle of having multiple passwords for different sites and writing them on the piece of paper. At the same time I fear the day where the only password I have will be exposed, so I needed a password manager similar to the popular app LastPass. The issue was I didn't want to pay anything and with all the cyber security issues this past decade I didn't want to have anymore of my data on the internet, so I made use of what I learned and wrote an app that does what I need it to do.",
      [
        ["Custom GUI", "/assets/Projects/GUI.png"],
        [
          "Custom Randomized Password Generator",
          "/assets/Projects/password generator.png",
        ],
        [
          "Built in querying for searches based on username/email",
          "/assets/Projects/Search.png",
        ],
        [
          "Local data storage on your computer",
          "/assets/Projects/local storage.png",
        ],
        [
          "Multiple profiles supported",
          "/assets/Projects/multiple users.png",
        ],
        [
          "Data Encryption via python's cryptography library",
          "/assets/Projects/encryption.png",
        ],
      ],
    ],
    [
      "Project Projectile",
      "A 3D shooter game situated in the browser where the user pivots a cannon about the X and Y axis to shoot targets on a wall.",
      [
        [
          "Random object instantiation",
          "/assets/Projects/random object instantiation.png",
        ],
        [
          "Unit collision detection",
          "/assets/Projects/collision detection.png",
        ],
        [
          "Custom texturing and 3D modelling",
          "/assets/Projects/texturing.png",
        ],
      ],
    ],
    [
      "ChatUp",
      "A chatting app that uses sockets to communicate between browser windows.",
      [
        ["Multiple profiles"],
        ["Multiple chatrooms per user"],
        ["Live chatroom message update"],
        ["Message reactions"],
        ["Text based message history search"],
      ],
    ],
    [
      "This website",
      "This is my take on a modern portfolio website!",
      [
        ["Light and Dark mode", "/assets/LightDarkMode.gif"],
        ["Reusable react components"],
        ["Multiple page routing", "/assets/PageRouting.gif"],
        ["Custom animations", "/assets/customAnimation.gif"],
        ["Dynamic rendering"],
      ],
    ],
    [
      "Daydream (In Development)",
      "Created by me and several other people as part of the UCLA ACM studios SRS 2023 event, a 2D turn based RPG inspired heavily by Jewish folklore. I am responsible for the in-game data structures and some turn based logic.",
    ],
    [
      "TASC (In Development)",
      "A health monitoring dashboard with smart wearables integration to help track your lifestyle goals and rewards you for it. My contributions towards this project are on the dashboard notifications.",
    ],
  ];

  return (
    <section className="SkillsPage">
      <p className="skillTitle">Skills</p>
      <div className="skillList">
        {skills.map((item) => {
          return (
            <li className="skill">
              <img className="skillLogo" src={item[1]} />
              <p className="skillName">{item[0]}</p>
            </li>
          );
        })}
      </div>
      <hr />
      <p className="projectTitle">Projects</p>
      <div className="projectList">
        {projects.map((item) => {
          return (
            <ProjectDisplay
              name={item[0]}
              description={item[1]}
              capabilities={item[2]}
            />
          );
        })}
      </div>
    </section>
  );
}

export default Skills;
