import React from "react";
import CategoryCardContainer from "./Components/CategoryCardContainer";
import Categories from "./Components/Categories";
import "./App.css";
import "bootstrap/dist/css/bootstrap.min.css";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";

function App() {
  return (
    <div className="App">
      <Router>
        <Switch>
          <Route exact path="/" component={CategoryCardContainer} />
          <Route path="/categories/:id" component={Categories} />
        </Switch>
      </Router>
    </div>
  );
}

export default App;
