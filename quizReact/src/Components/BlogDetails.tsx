import { Link, useParams } from "react-router-dom";
import type { Blog } from "../Types/Blog";

interface BlogDetailsProps {
  blogs: Blog[];
}

function BlogDetails({ blogs }: BlogDetailsProps) {
  const { id } = useParams();

  const blog = blogs.find((blog) => blog.id === Number(id));

  if (!blog) {
    return <h2>Blog not found</h2>;
  }

  return (
    <div>
      <h1>{blog.title}</h1>

      <p>Author: {blog.author}</p>

      <p>{blog.content}</p>

      <Link to="/">Back to Home</Link>
    </div>
  );
}

export default BlogDetails;
