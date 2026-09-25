import { useContext, useState } from "react";
import { UserContext } from "../context/UserContext";
import type { User } from "../Types/User";

interface LoginFormProps {
  onLogin: () => void;
}

function LoginForm({ onLogin }: LoginFormProps) {
  const context = useContext(UserContext);

  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState("");

  if (!context) return null;

  const { setUser } = context;

  function handleLogin(e: React.FormEvent<HTMLFormElement>) {
    e.preventDefault();

    const savedUser = localStorage.getItem("user");

    if (!savedUser) {
      setError("No registered user found");
      return;
    }

    const user: User = JSON.parse(savedUser);

    if (user.email === email && user.password === password) {
      setUser(user);
      setError("");
      onLogin();
    } else {
      setError("Invalid email or password");
    }
  }

  return (
    <form onSubmit={handleLogin}>
      <h2>Login</h2>

      <div>
        <label>Email</label>

        <input
          type="email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
        />
      </div>

      <div>
        <label>Password</label>

        <input
          type="password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
        />
      </div>

      {error && <p>{error}</p>}

      <button type="submit">Login</button>
    </form>
  );
}

export default LoginForm;
