import { useContext } from "react";
import { UserContext } from "../context/UserContext";

function Navbar() {
  const context = useContext(UserContext);

  if (!context) return null;

  const { user } = context;

  return (
    <nav>
      <h2>User Profile Manager</h2>

      {user && <p>Welcome, {user.fullName}</p>}
    </nav>
  );
}

export default Navbar;
