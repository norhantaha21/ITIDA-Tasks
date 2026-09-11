import { products } from "../../Data/products";
import ProductCard from "../ProductCard/ProductCard";
import "./ProductList.css";

function ProductList() {
  return (
    <div className="product-list">
      {products.map((product) => (
        <ProductCard key={product.id} product={product} />
      ))}
    </div>
  );
}
export default ProductList;
