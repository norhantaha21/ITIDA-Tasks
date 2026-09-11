import type { Product } from "../../Types/Product";
import "./ProductCard.css";

interface ProductCardProps {
  product: Product;
}

function ProductCard({ product }: ProductCardProps) {
  return (
    <div className="product-card">
      <img
        className="product-card img"
        src={product.image}
        alt={product.name}
      />
      <h3>{product.name}</h3>
      <p>{product.brand}</p>
      <p>{product.price} EGP</p>
      <p style={{ color: product.inStock ? "green" : "red" }}>
        {product.inStock ? "In Stock" : "Out of Stock"}
      </p>
    </div>
  );
}

export default ProductCard;
