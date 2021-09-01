import Head from 'next/head'
import { If, Then, Else, When } from 'react-if';
import {useState} from 'react';

export default function Home() {

  const [people, setPeople] = useState([]);
  const [person, setPerson] = useState("");

  const handleChange = (e) => {
    setPerson( e.target.value );
  }

  const addPerson = (e) => {
    e.preventDefault();
    e.target.reset();
    setPeople( [...people, person] );
  }

  return (
    <>
      <h2>Today's Demo</h2>
      <form onSubmit={addPerson}>
        <input onChange={handleChange} placeholder="Person..." />
      </form>

      <hr />
      <If condition={people.length >= 1}>
       <Then>
          <h2>People List</h2>
          <ul>
            {
              people.map( (person, idx) =>
                <li key={idx}>{person}</li>
              )
            }
          </ul>
       </Then>
       <Else>
         <div>
           Please use the form to add a person or three
         </div>
       </Else>
      </If>
    </>
  )
}
