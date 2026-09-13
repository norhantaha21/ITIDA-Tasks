import { useState } from "react";
import type { Blog } from "../Types/Blog";

function Home() {
  const [blogs, setBlog] = useState<Blog[]>([
    { id: 1, title: "title1", content: "content1", author: "Ahmed" },
    { id: 2, title: "title2", content: "content2", author: "Mohamed" },
  ]);

  function addBlog(blog: Blog) {
    setBlog([...blogs, blog]);
  }

  function RemoveBlog(index: number) {
    setBlog(blogs.filter((_, i) => i !== index));
  }

  return (
    <div>
      <h1>Blogs</h1>
      {blogs.map((blog) => (
        <Blog key={blog.id} title={blog.title} content={blog.content} />
      ))}

      <button
        onClick={() => {
          RemoveBlog;
        }}
      >
        Remove Blog
      </button>
    </div>
  );
}

export default Home;
