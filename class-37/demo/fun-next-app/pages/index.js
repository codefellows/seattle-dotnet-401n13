import Head from 'next/head'

import React, {useState} from 'react';


export default function Home() {

  const [words, setWords] = useState('Starter State');
  const [allThings, setAllThings] = useState({});

  const handleChange = (e) => {
    setWords(e.target.value);

    /// What if we had multiple fields?
    // e.target.value
    // e.target.name
    // setAllThings with the name and value as props ...
  };

  return (
    <>
    <div>{words}</div>
    <input name="animal" onChange={handleChange} />
    </>
  );
}
