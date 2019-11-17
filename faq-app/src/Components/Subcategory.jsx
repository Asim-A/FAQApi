import React, { Component, Fragment } from "react";
import Questions from "./Questions";
import "../Subcategory.css";

class Subcategory extends Component {
  constructor(props) {
    super(props);
  }

  componentDidMount() {}

  render() {
    return (
      <div className="subcategory">
        <h2>{this.props.title}</h2>
        <Questions sub_id={this.props.id}></Questions>
      </div>
    );
  }
}

export default Subcategory;
