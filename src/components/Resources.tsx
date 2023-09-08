import "../styles/Resources.css";

let resourceList: [string, string, string, string][] = [
  [
    "LinkedIn:",
    "https://www.linkedin.com/in/haoxiankang/",
    "Add me!",
    "/assets/linkedIn.png",
  ],
  [
    "Github:",
    "https://github.com/CohenK",
    "Let's collab!",
    "/assets/github-mark.png",
  ],
  [
    "Resume:",
    "https://docs.google.com/document/d/1FC_khZLHGMQEIDvxo2p9lfIG2M15zLC1/edit?usp=sharing&ouid=101433293086238194766&rtpof=true&sd=true",
    "Copy of my resume on Google Drive",
    "/assets/resume.png",
  ],
  [
    "Email:",
    "mailto:kangcohen@gmail.com",
    "kangcohen@gmail.com",
    "/assets/gmail.png",
  ],
];

function Resources() {
  return (
    <section className="ResourcesPage">
      <p className="resourcesTitle">Here are some resources</p>
      {resourceList.map((item) => {
        return (
          <div className="resourceListItem">
            <div className="iconContainer">
              <img className="resourceIcon" src={item[3]}></img>
            </div>
            <div className="itemName">{item[0]}</div>
            <div className="actualLink">
              <a className="resourceListLink" href={item[1]} target="_blank">
                {item[2]}
              </a>
            </div>
          </div>
        );
      })}
    </section>
  );
}

export default Resources;
