import React from "react";


const Accordion = () => {


  const handleClick = (evt) => {

  }

  return (
    <div class="accordion">
      <button onClick={handleClick}>
          <h2 class="accordion-header">

          </h2>
      </button>
      <div class="task-list">
        <div class="task-list-item" onclick="showbox()">
          <p class="task-list-item-text">Task 1</p>
          <i class="fas fa-chevron-down"></i>
        </div>
        <div class="task-list-item-extra" id="taskshow">
          <p class="task-list-item-text">
            Lorem ipsum dolor sit amet consectetur adipisicing elit. Est,
            impedit vitae! Molestiae earum ea dignissimos necessitatibus debitis
            alias possimus accusantium quo maiores aspernatur labore, beatae
            error eligendi modi repellat obcaecati?
          </p>
        </div>
      </div>
    </div>
  );
};

export default Accordion;
