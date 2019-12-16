import React, { useState, createContext, useEffect } from "react";
import http from "../services/http";
import axios from "axios";

export const UserContext = createContext();

const UserContextProvider = props => {
  const [user, setUser] = useState();
  const [isLogged, setIsLogged] = useState(false);
  const [error, setError] = useState();
  const [token, setToken] = useState();
  const [isAdmin, setIsAdmin] = useState();

  const handleUserInputs = async (username, password) => {
    await axios({
      method: "post",
      url: "users/authenticate",
      data: {
        username: `${username}`,
        password: `${password}`
      }
    })
      .then(res => {
        setToken(res.data.token);
        setUser(res.data);
        setIsLogged(true);
        sessionStorage.setItem("user", JSON.stringify(res.data));
      })
      .catch(e => setError(e));
    console.log(JSON.parse(sessionStorage.getItem("user")));
  };

  const handleLogout = () => {
    setIsLogged(false);
    sessionStorage.clear();
    console.log(isLogged, user);
  };

  return (
    <UserContext.Provider
      value={{
        handleUserInputs,
        user,
        setUser,
        isAdmin,
        token,
        error,
        handleLogout,
        isLogged,
        setIsLogged
      }}
    >
      {props.children}
    </UserContext.Provider>
  );
};

export default UserContextProvider;
