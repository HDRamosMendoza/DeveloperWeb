import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './AuthenticatedApp';
import { AuthProvider } from "./context/AuthContext";

ReactDOM.render(
    <AuthProvider><App/></AuthProvider>,
    document.getElementById('root')
);
