import { useState } from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import type { Blog } from "./Types/Blog";
import Home from "./Components/Home";
import BlogDetails from "./Components/BlogDetails";

function App() {
  const [blogs, setBlogs] = useState<Blog[]>([
    {
      id: 1,
      title: "React Basics",
      content: "React is a JavaScript library for building user interfaces.",
      author: "Nourhan",
    },
    {
      id: 2,
      title: "TypeScript",
      content: "TypeScript adds static typing to JavaScript.",
      author: "Ahmed",
    },
    {
      id: 3,
      title: "React Router",
      content: "React Router helps us navigate between pages.",
      author: "Sara",
    },
  ]);

  const removeBlog = (id: number) => {
    setBlogs(blogs.filter((blog) => blog.id !== id));
  };

  return (
    <BrowserRouter>
      <Routes>
        <Route
          path="/"
          element={<Home blogs={blogs} removeBlog={removeBlog} />}
        />

        <Route path="/blog/:id" element={<BlogDetails blogs={blogs} />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
