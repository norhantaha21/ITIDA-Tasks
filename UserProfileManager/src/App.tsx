import { useCallback, useContext, useState } from "react";
import Navbar from "./components/Navbar";
import RegistrationForm from "./components/RegistrationForm";
import LoginForm from "./components/LoginForm";
import ProfileCard from "./components/ProfileCard";
import { UserContext } from "./context/UserContext";
import "./App.css";

function App() {
  const context = useContext(UserContext);

  const [page, setPage] = useState<"register" | "login" | "profile">(
    "register",
  );

  if (!context) return null;

  const { user, setUser } = context;

  const handleEdit = useCallback(() => {
    setPage("register");
  }, []);

  const handleLogout = useCallback(() => {
    localStorage.removeItem("user");

    setUser(null);

    setPage("login");
  }, [setUser]);

  return (
    <>
      <Navbar />

      <main>
        {!user && page === "register" && (
          <>
            <RegistrationForm onSuccess={() => setPage("profile")} />

            <button onClick={() => setPage("login")}>
              Already have an account? Login
            </button>
          </>
        )}

        {!user && page === "login" && (
          <>
            <LoginForm onLogin={() => setPage("profile")} />

            <button onClick={() => setPage("register")}>
              Create a new account
            </button>
          </>
        )}

        {user && <ProfileCard onEdit={handleEdit} onLogout={handleLogout} />}
      </main>
    </>
  );
}

export default App;
