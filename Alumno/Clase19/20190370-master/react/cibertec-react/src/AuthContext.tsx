import React from "react";
import { async } from "q";

const localStorageTokenKey = "__token_key";

export const AuthContext = React.createContext({
    isAuthenticated: async():Promise<boolean> => false
});

export const AuthProvider: React.FC = (props) => {
    const isAuthenticatedProvider = async () => {
        try {
            // Obtener el valor del token del localStorage
            const token = window.localStorage.getItem(localStorageTokenKey);
            if(!token) {
                return false;
            }
            return false;
        } catch(error) {
            console.error(error);
            return false;
        }

    };

    return <AuthContext.Provider value={
        {isAuthenticated: isAuthenticatedProvider}
        }> {props.children}
    </AuthContext.Provider>
}