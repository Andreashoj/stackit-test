import React, { useContext, useEffect, useState } from "react";
import Navigation from "./components/Navigation/Navigation.jsx";
import Sidebar from "./components/Sidebar/Sidebar.jsx";
import { BrowserRouter as Router, Route } from "react-router-dom";
import MobileContextProvider from "./context/MobileContext";
import Login from "./routes/Login/Login";
import "./App.scss";
import { UserContext } from "./context/UserContext.jsx";

function App() {
  const [routes, setRoutes] = useState(<Route path="/" component={Login} />);
  const { handleLogout, handleUserInputs, isLogged } = useContext(UserContext);

  const user = JSON.parse(sessionStorage.getItem("user"));
  useEffect(() => {
    console.log("yo", user);
    if (!user && !isLogged) {
      setRoutes(
        <>
          <Route path="/" component={Login} />;
        </>
      );
    } else {
      setRoutes(
        <>
          <Navigation />
          <Sidebar />
        </>
      );
    }
  }, [handleUserInputs, handleLogout]);

  return (
    <Router>
      <nav className="nav-wrapper">
        <MobileContextProvider>{routes}</MobileContextProvider>
      </nav>
    </Router>
  );
}

export default App;
