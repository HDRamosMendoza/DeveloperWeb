import React from 'react';
import logo from './logo.svg';
import './App.css';
import {Table} from "./components/Table";

const App: React.FC = () => {
  const array = [1,2,3,4,5,6,7];
  const array1:[10] = [10]
  const arrayTables = [];

  for (let index= 0; index < 50; index++) {
    arrayTables.push(<Table title={`Tabla ${index}`}></Table>)
  }

  //const tableViews = array.map((index) => {
  //  return <Table title={`Tabla ${index}`}></Table>
  //})

  return (
    <>
      {arrayTables}
    </>
  );
}

export default App;