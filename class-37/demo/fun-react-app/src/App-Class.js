import logo from './logo.svg';
import './App.css';
import React from 'react';

//        : in c#
class App extends React.Component {

  constructor(props) {
    super(props); // In C#, this is ... base();
    this.state = {
      words: "Hi World"
    };
  }

  handleChange = (e) => {
    this.setState({words:e.target.value})
  }

  handleSubmit = (e) => {
    e.preventDefault();
  }

  render() {
    return (
      <main>
        <h2>
          {this.state.words}
        </h2>
        <form onSubmit={this.handleSubmit}>
          <input onChange={this.handleChange} />
        </form>
      </main>
    )
  }

}

export default App;
