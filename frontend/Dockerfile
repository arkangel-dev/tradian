#Dockerfile

# Use this image as the platform to build the app

FROM node:23.3 AS external-website

# Set the working directory to /app
WORKDIR /app

# Copy the package.json and package-lock.json to the working directory
COPY ./package*.json .

# Install the dependencies
RUN npm install

# Copy the remaining application files to the working directory
COPY . .

# Build the application
WORKDIR /app
RUN npm ci
RUN npm run build

# Start the application
CMD ["node","build/index.js"]