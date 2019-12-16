import React, { useContext, useState } from "react";
import { UserContext } from "../../context/UserContext";
import logo from "../../assets/icons/logo_stackit.svg";

const LoginForm = () => {
  const { handleUserInputs, error } = useContext(UserContext);
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");

  const handleForm = e => {
    e.preventDefault();
    handleUserInputs(username, password);
  };

  return (
    <div className="login-container">
      <div className="form-wrapper">
        <form className="form-container" onSubmit={e => handleForm(e)}>
          <img className="login-container__logo" src={logo} alt="" />
          {error && <h1 className="Error">Username or Password is wrong</h1>}
          <div className="form-input">
            <label htmlFor="username">Username</label>
            <input
              type="text"
              name="username"
              id="username"
              value={username}
              onChange={e => setUsername(e.target.value)}
            />
          </div>
          <div className="form-input">
            <label htmlFor="password">Password</label>
            <input
              type="password"
              name="password"
              id="password"
              value={password}
              onChange={e => setPassword(e.target.value)}
            />
          </div>
          <button type="submit">Login</button>
        </form>
      </div>
      .
    </div>
  );
};

export default LoginForm;
