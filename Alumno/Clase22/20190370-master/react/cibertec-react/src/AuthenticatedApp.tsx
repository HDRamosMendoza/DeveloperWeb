import React, { useEffect } from 'react';
import { ListView } from "./components/ListView";
import { getProducts } from "./service";
import { InsertView } from './components/InsertView';
import { EditView } from './components/EditView';
import { AuthContext } from './context/AuthContext';

interface IProps {
  checkSessionAction: () => void;
}

const AuthenticatedApp: React.FC<IProps> = (props) => {
  const authContext = React.useContext(AuthContext);
  const cerrarSesion = () => {
    // cerrar sesión (borrar el token del local storage)
    authContext.signOut();
    // actualizamos la sesión
    props.checkSessionAction();
  }
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
    <>
      <nav className="navbar is-link" role="navigation" aria-label="main navigation">
        <div className="navbar-brand">
          <a className="navbar-item" href="#">
            <img src="https://www.cibertec.edu.pe/wp-content/themes/cibertec/statics/img/logo-white.svg" width="112" height="28" />
          </a>

          <a role="button" className="navbar-burger burger" aria-label="menu" aria-expanded="false" data-target="navbarBasicExample">
            <span aria-hidden="true"></span>
            <span aria-hidden="true"></span>
            <span aria-hidden="true"></span>
          </a>
        </div>

        <div id="navbarBasicExample" className="navbar-menu">
          <div className="navbar-start">
            <a className="navbar-item">
              Home
            </a>
          </div>

          <div className="navbar-end">
            <div className="navbar-item">
              <div className="buttons">
                <a className="button is-light" onClick={() => {
                  cerrarSesion();
                }}>
                  Cerrar Sesión
                </a>
              </div>
            </div>
          </div>
        </div>
      </nav>

      <div className="container is-fluid">
        {obtenerVista()}
      </div>
    </>
  );
}

export default AuthenticatedApp;
