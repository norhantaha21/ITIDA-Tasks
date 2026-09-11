import type { Product } from "../Types/Product";
import phoneImg from "../assets/phone.avif";
import laptopImg from "../assets/laptop.avif";
import headphonesImg from "../assets/headphones.webp";
import watchImg from "../assets/watch.jpg";
import shoesImg from "../assets/shoes.jpg";
import bagImg from "../assets/bag.jpg";

export const products: Product[] = [
  {
    id: 1,
    name: "Phone",
    brand: "Apple",
    price: 45000,
    image: phoneImg,
    inStock: true,
  },
  {
    id: 2,
    name: "laptop",
    brand: "Samsung",
    price: 32000,
    image: laptopImg,
    inStock: false,
  },
  {
    id: 3,
    name: "HeadPhone",
    brand: "Sony",
    price: 12000,
    image: headphonesImg,
    inStock: true,
  },
  {
    id: 4,
    name: "Watch",
    brand: "Apple",
    price: 18000,
    image: watchImg,
    inStock: true,
  },
  {
    id: 5,
    name: "Shoes",
    brand: "Nike",
    price: 5500,
    image: shoesImg,
    inStock: false,
  },
  {
    id: 6,
    name: "Bag",
    brand: "Zara",
    price: 2200,
    image: bagImg,
    inStock: true,
  },
];
