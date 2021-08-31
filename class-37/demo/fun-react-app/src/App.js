import React, {useState} from 'react';

// A class renders what the render method returns...
// A funtion renders what IT returns
function App() {

  const [words, setWords] = useState('Help');
  const [charactersTyped, setCharactersTyped] = useState(0);

  function handleChange(e) {
    // this.setState({words: e.target.value})
    setWords(e.target.value);
    setCharactersTyped( charactersTyped + 1);
  }

  const handleSubmit = (e) => {
    e.preventDefault();
    setCharactersTyped(0);
  }

  return (
    <>
    <h2>{words}</h2>
    <h3>{charactersTyped}</h3>
    <form onSubmit={handleSubmit}>
      <input onChange={handleChange} />
    </form>
    </>
  );

}

export default App;

/*
  let C1 =  new App();
  let output = Ci.render();
  dom.Insert(output, "#root");

  let output = C1();
  dom.Insert(output, "#root");


  Why can't we return:

    <div></div>
    <div></div>

    this is the same as:
      return a, b;

  Insead:
    <>
      <div></div>
      <div></div>
    </>

    return a; // a is [c,d]
*/
