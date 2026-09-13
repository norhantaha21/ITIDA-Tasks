import { Link } from "react-router-dom";
import type { Blog } from "../Types/Blog";

interface HomeProps {
  blogs: Blog[];
  removeBlog: (id: number) => void;
}

function Home({ blogs, removeBlog }: HomeProps) {
  return (
    <div>
      <h1>Blogs</h1>

      {blogs.map((blog) => (
        <div key={blog.id}>
          <h2>{blog.title}</h2>

          <p>Author: {blog.author}</p>

          <Link to={`/blog/${blog.id}`}>View Blog</Link>

          <button onClick={() => removeBlog(blog.id)}>Remove</button>

          <hr />
        </div>
      ))}
    </div>
  );
}

export default Home;
