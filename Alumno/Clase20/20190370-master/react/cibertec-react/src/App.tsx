import React from "react";
import "./App.scss";
import AuthenticatedApp from "./AuthenticatedApp";
import { AuthContext } from "./context/AuthContext";
import { UnauthenticatedApp } from "./UnauthenticatedApp";

const App = () => {
    const [userAuthenticated, setUserAuthenticated] = React.useState(false);
    const authContext = React.useContext(AuthContext);

    const checkSession = async () => {
        const isAuthenticated = await authContext.isAuthenticated();
        console.log(isAuthenticated);
        setUserAuthenticated(isAuthenticated);
    }

    // para ver si el usuario está autenticado al montar el componente
    React.useEffect(() => {
        checkSession();
    }, [])

    return userAuthenticated ? <AuthenticatedApp></AuthenticatedApp> : <UnauthenticatedApp checkSessionAction={checkSession}></UnauthenticatedApp>;
}

export default App;