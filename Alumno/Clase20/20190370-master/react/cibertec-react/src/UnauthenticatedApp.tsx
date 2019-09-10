import React from "react";
import { getUserToken } from "./service";
import { AuthContext } from "./context/AuthContext";

interface IProps {
  checkSessionAction: () => void
}

export const UnauthenticatedApp: React.FC<IProps> = (props) => {
  const [showErrors, setShowErrors] = React.useState(false);

  const authContext = React.useContext(AuthContext);
  const handleSubmit = async (e: any) => {
    e.preventDefault();
    const [userInput, passwordInput] = e.target.elements;
    const validationResponse = await getUserToken({ username: userInput.value, password: passwordInput.value });
    if (validationResponse.status === "success") {
      // se generó el token, guardarlo en el local storage
      await authContext.saveToken(validationResponse.data);
      setShowErrors(false);

      // volvemos a chequear la sesión del padre
      props.checkSessionAction();
    }
    else {
      setShowErrors(true);
    }
  }
  return (
    <section className="hero is-primary is-fullheight">
      <div className="hero-body">
        <div className="container">
          {showErrors && <div className="columns is-centered">
            <div className="column is-5-tablet is-4-desktop is-3-widescreen">
              <div className="notification is-danger">
                <button className="delete" onClick={() => { setShowErrors(false) }}></button>
                Ocurrió un error de inicio de sesión. Verifica los datos ingresados
              </div>
            </div>
          </div>}
          <div className="columns is-centered">
            <div className="column is-5-tablet is-4-desktop is-3-widescreen">
              <form action="" className="box" onSubmit={handleSubmit}>
                <div className="field">
                  <label className="label">Email</label>
                  <div className="control has-icons-left">
                    <input type="email" placeholder="e.g. bobsmith@gmail.com" className="input" required />
                    <span className="icon is-small is-left">
                      <i className="fa fa-envelope"></i>
                    </span>
                  </div>
                </div>
                <div className="field">
                  <label className="label">Password</label>
                  <div className="control has-icons-left">
                    <input type="password" placeholder="*******" className="input" required />
                    <span className="icon is-small is-left">
                      <i className="fa fa-lock"></i>
                    </span>
                  </div>
                </div>
                <div className="field">
                  <button className="button is-success">
                    Login
                  </button>
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
    </section>
  )
}