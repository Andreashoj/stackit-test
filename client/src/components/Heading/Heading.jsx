import React from "react";

const Heading = ({ title, desc }) => {
  return (
    <div className="heading">
      <h2 className="headingTitle">{title}</h2>
      <p className="headingDesc">{desc}</p>
    </div>
  );
};

export default Heading;
