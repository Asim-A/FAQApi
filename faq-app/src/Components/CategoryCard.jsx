import React, { Component, Fragment } from "react";
import Card from "react-bootstrap/Card";
import Categories from "./Categories";
import { Link, Route } from "react-router-dom";

class CategoryCard extends Component {
  constructor(props) {
    super(props);
  }

  createCard = () => {
    let id = this.props.category_id;
    let href = "/categories/" + id;
    return (
      <Card className="category-card">
        <Card.Body>
          <Card.Title>
            <Link
              to={href}
              className="card-text"
              data-id={this.props.category_id}
            >
              {this.props.category_title}
            </Link>
          </Card.Title>
        </Card.Body>
      </Card>
    );
  };

  render() {
    return <Fragment>{this.createCard()}</Fragment>;
  }
}

export default CategoryCard;
