import { useState } from "react";
import "./App.css";
import type { Blog } from "./Types/Blog";
import Home from "./Components/Home";

function App() {
  const [count, setCount] = useState(0);

  return <Home />;
}

export default App;
