import React, { useState, useRef } from "react";
import "../Accordion.css";
import Chevron from "./Chevron";

function Accordion(props) {
  const [setActive, setActiveState] = useState("");
  const [setHeight, setHeightState] = useState("0px");
  const [setRotate, setRoateState] = useState("accordion-icon");

  const answer = useRef(null);

  function toggleAccordion() {
    setActiveState(setActive === "" ? "active" : "");
    setHeightState(
      setActive === "active" ? "0px" : `${answer.current.scrollHeight}px`
    );
    setRoateState(
      setActive === "active" ? "accordion-icon" : "accordion-icon rotate"
    );
  }

  return (
    <div className="accordion-section">
      <button className={`accordion ${setActive}`} onClick={toggleAccordion}>
        <div className="accordion-title">{props.question_body}</div>
        <Chevron className={`${setRotate}`} width={10} fill={"#777"} />
      </button>
      <div
        ref={answer}
        className="accordion-content"
        style={{ maxHeight: `${setHeight}` }}
      >
        <div
          className="accordion-text"
          dangerouslySetInnerHTML={{ __html: props.answer }}
        ></div>
      </div>
    </div>
  );
}

export default Accordion;
