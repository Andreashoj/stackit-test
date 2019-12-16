import React, { useState, useEffect } from "react";
import { Link, Switch, Route, Redirect } from "react-router-dom";
import DashBoard from "../../routes/Dashboard/DashBoard";
import logo from "../../assets/icons/logo_stackit.svg";
import dashboard from "../../assets/icons/dashboard.svg";
import NotFound from "../NotFound/NotFound";
import MachineList from "../List/machine/machineList";
import MachineDetails from "../../routes/Machine/MachineDetails";
import JobForm from "../JobForm/JobForm";
import OpeDetails from "../List/ope/OpeDetails";
import http from "../../services/http";
import OpeList from "../List/opeList/OpeList";

const Sidebar = () => {
  const [userType, setUserType] = useState({
    type: "s_admin"
  });

  let listItem_operator = null;
  if (userType.type === ("s_admin" || "k_admin")) {
    listItem_operator = (
      <ul className="sidebar-nav__item">
        <Link className="link" to="/operators">
          <img className="sidebar-nav__icon" src={dashboard} alt="" />
          Operators
        </Link>
      </ul>
    );
  }

  return (
    <>
      <nav className="sidebar-nav">
        <div className="sidebar-nav__wrapper">
          <img src={logo} alt="Something here" />
          <h3 className="sidebar-nav__header">Menu</h3>
          <ul>
            <ul className="sidebar-nav__item">
              <Link className="link" to="/">
                <img className="sidebar-nav__icon" src={dashboard} alt="" />
                Dashboard
              </Link>
            </ul>

            <ul className="sidebar-nav__item">
              <Link className="link" to="/machines">
                <img className="sidebar-nav__icon" src={dashboard} alt="" />
                Machines
              </Link>
              <li className="sidebar-nav__list-item">
                <Link to="/jobs">- Create Job</Link>
              </li>
            </ul>
            {listItem_operator}
          </ul>
        </div>
      </nav>
      <main className="component-container">
        <Switch>
          <Route path="/machines/:id" component={MachineDetails} />
          <Route path="/machines" component={MachineList} />
          <Route path="/jobs" component={JobForm} />
          <Route path="/operators/:id" component={OpeDetails} />
          <Route path="/operators" component={OpeList} />
          <Route path={"/not-found"} component={NotFound} />
          <Route exact path={["/", "/dashboard"]} component={DashBoard} />
          <Redirect to="/not-found" />
        </Switch>
      </main>
    </>
  );
};

export default Sidebar;
