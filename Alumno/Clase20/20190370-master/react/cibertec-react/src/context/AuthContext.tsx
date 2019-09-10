import React from "react";

const localStorageTokenKey = "__token_key";

export const AuthContext = React.createContext({
    isAuthenticated: async (): Promise<boolean> => false,
    saveToken: async (token: string): Promise<void> => { },
    signOuot: () => {}
})

export const AuthProvider: React.FC = (props) => {
    const isAuthenticatedProvider = async (): Promise<boolean> => {
        try {
            // obtener el valor del token del local storage
            const token = window.localStorage.getItem(localStorageTokenKey);
            if (!token) {
                return false;
            }
            return true;
        } catch (error) {
            console.error(error);
            return false;
        }
    }
    const saveTokenProvider = async (token: string) => {
        window.localStorage.setItem(localStorageTokenKey, token);
    }

    const singOutProvider = () => {
        window.localStorage.removeItem(localStorageTokenKey);
    }

    return <AuthContext.Provider value={{ isAuthenticated: isAuthenticatedProvider, saveToken: saveTokenProvider }}>
        {props.children}
    </AuthContext.Provider>
}