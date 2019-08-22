import React, { useEffect } from 'react';
import logo from './logo.svg';
import './App.css';
import { Table } from "./components/Table";
import { ListView } from "./components/ListView";
import { getProducts } from "./service";

interface IProducto {
  nombre: string;
  precio: number;
}

interface ICliente {
  nombre: string;
  apellido: string;
  edad: number;
}

const App: React.FC = () => {
  // utilizar useEffect de React para cargar la data al momento de pintar el componente
  const getData = async () => {
    const productos = await getProducts();
    console.log(productos);
  }

  useEffect(() => {
    getData();
  }, [])

  return (
    <>
      <ListView></ListView>
    </>
  );
}

export default App;
