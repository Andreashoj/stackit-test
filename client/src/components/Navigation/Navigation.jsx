import React, { useContext } from "react";
import logout from "../../assets/icons/logout.svg";
import { MobileContext } from "../../context/MobileContext";
import MobileNav from "./MobileNav";
import { useHistory } from "react-router-dom";
import { UserContext } from "../../context/UserContext";

const Navigation = () => {
  let history = useHistory();
  const user = JSON.parse(sessionStorage.getItem("user"));
  const { userType } = user;
  const { handleLogout } = useContext(UserContext);
  /*const [notification, setNotification] = useState({
    notification: 1
  });*/

  const { isMobile } = useContext(MobileContext);

  const handleLogoutButton = e => {
    handleLogout();
  };

  if (!isMobile) {
    return (
      <nav className="nav">
        <div className="nav__wrapper">
          <a
            className="nav__icon"
            href="/"
            onClick={e => handleLogoutButton(e)}
          >
            <img src={logout} alt="" />
          </a>
        </div>
      </nav>
    );
  } else {
    return <MobileNav userType={userType} />;
  }
};

export default Navigation;
