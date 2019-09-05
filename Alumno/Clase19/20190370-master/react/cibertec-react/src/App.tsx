import React from "react";
import "./App.scss";
import AuthenticatedApp from "./AuthenticatedApp";
import AuthContext from "./context/AuthContext";

const App = () => {
    const [userAuthenticated, setUserAuthenticated] = React.useState(false);
    const authContext = React.useContext(AuthContext);

    const checkSession = async()=> {
        const isAuthenticated = await authContext.isAuthenticated;
        console.log(isAuthenticated);
        setUserAuthenticated(isAuthenticated);
    }

    // Para 
    React.useEffect(() => {
        checkSession();
    }, [])

    const isAuthenticated = authContext.isAuthenticated();    
    console.log(isAuthenticated);
    return isAuthenticated ? <AuthenticatedApp></AuthenticatedApp>: <div>Usuario no autenticado</div>;
}

export default App;