import React, { useEffect, useRef, useState } from 'react';
import './ScrollInFromSide.css'; // Include the CSS styles

const ScrollInFromSide = ({ children, direction = 'left', offset = 100 }) => {
  const [isVisible, setIsVisible] = useState(false);
  const elementRef = useRef(null);

  useEffect(() => {
    const handleScroll = () => {
      if (elementRef.current) {
        const rect = elementRef.current.getBoundingClientRect();
        const isInView =
          rect.top <= window.innerHeight - offset && rect.bottom >= 0;

        if (isInView) {
          setIsVisible(true);
        }
      }
    };

    window.addEventListener('scroll', handleScroll);
    handleScroll(); // Run on initial render
    return () => window.removeEventListener('scroll', handleScroll);
  }, [offset]);

  const slideDirection =
    direction === 'right'
      ? 'translateX(100%)'
      : direction === 'top'
      ? 'translateY(-100%)'
      : direction === 'bottom'
      ? 'translateY(100%)'
      : 'translateX(-100%)';

  return (
    <div
      ref={elementRef}
      className={`slide-in ${isVisible ? 'active' : ''}`}
      style={{
        transform: isVisible ? 'translate(0, 0)' : slideDirection,
        opacity: isVisible ? 1 : 0,
        transition: 'opacity 0.5s ease, transform 0.5s ease',
      }}
    >
      {children}
    </div>
  );
};

export default ScrollInFromSide;
