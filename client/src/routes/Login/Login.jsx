import React, { useContext } from "react";
import { Redirect } from "react-router-dom";
import LoginForm from "./LoginForm";
import { UserContext } from "../../context/UserContext";

const Login = () => {
  const user = JSON.parse(sessionStorage.getItem("user"));
  const { isLogged, setIsLogged } = useContext(UserContext);

  if (!isLogged) {
    return <LoginForm />;
  } else {
    return null;
  }
};

export default Login;
