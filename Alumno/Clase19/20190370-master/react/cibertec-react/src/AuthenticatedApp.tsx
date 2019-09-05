import React, { useEffect } from 'react';
import logo from './logo.svg';
import './App.scss';
import { Table } from "./components/Table";
import { ListView } from "./components/ListView";
import { getProducts } from "./service";
import { InsertView } from './components/InsertView';
import { EditView } from './components/EditView';

const AuthenticatedApp: React.FC = () => {
  // crear un state para manejar las vistas
  const [vistaActual, setVistaActual] = React.useState("lista");

  const [idProductEditar, setIdProductEditar] = React.useState(1);
  // utilizar useEffect de React para cargar la data al momento de pintar el componente
  const getData = async () => {
    const productos = await getProducts();
    console.log(productos);
  }

  const onEdit = (id: number) => {
    setIdProductEditar(id);
    setVistaActual("editar");
  }

  useEffect(() => {
    getData();
  }, [])

  // obtener la vista a pintar, de acuerdo al valor de vistaActual

  const obtenerVista = () => {
    switch (vistaActual) {
      case "lista": return <ListView cambiarVistaProp={cambiarVista} onEditClick={onEdit}></ListView>
      case "insertar": return <InsertView cambiarVistaProp={cambiarVista}></InsertView>
      case "editar": return <EditView idProducto={idProductEditar} cambiarVistaProp={cambiarVista}></EditView>
      default: return <div>No existe la vista</div>
    }
  }

  const cambiarVista = (vistaNueva: string) => {
    setVistaActual(vistaNueva);
  }

  return (
    <div className="container is-fluid">
      {obtenerVista()}
    </div>
  );
}

export default AuthenticatedApp;
