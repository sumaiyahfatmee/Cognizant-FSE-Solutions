import React, { Component } from "react";
import CurrencyConvertor from "./CurrencyConvertor";

class App extends Component {

  constructor() {
    super();

    this.state = {
      count: 0
    };
  }

  increment = () => {
    this.setState({
      count: this.state.count + 1
    });
  };

  decrement = () => {
    this.setState({
      count: this.state.count - 1
    });
  };

  sayHello = () => {
    alert("Hello! Welcome to React Event Handling.");
  };
  sayWelcome = (message) => {
  alert(message);
};
onPress = () => {
  alert("I was clicked");
};

  handleIncrement = () => {
    this.increment();
    this.sayHello();
  };

  render() {
    return (
      <div style={{ padding: "20px" }}>
        <h1>Counter : {this.state.count}</h1>

        <button onClick={this.handleIncrement}>
          Increment
        </button>

        &nbsp;&nbsp;

        <button onClick={this.decrement}>
          Decrement
        </button>
        <br /><br />

<button onClick={() => this.sayWelcome("Welcome")}>
  Say Welcome
</button>
<br /><br />

<button onClick={this.onPress}>
  OnPress
</button>
<br /><br />

<CurrencyConvertor />
      </div>
      
    );
  }
  
}

export default App;