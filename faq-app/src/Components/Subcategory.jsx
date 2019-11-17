import React, { Component, Fragment } from "react";
import Questions from "./Questions";

class Subcategory extends Component {
  constructor(props) {
    super(props);
  }

  componentDidMount() {}

  render() {
    return (
      <Fragment>
        <h1>{this.props.title}</h1>
        <Questions sub_id={this.props.id}></Questions>
      </Fragment>
    );
  }
}

export default Subcategory;
