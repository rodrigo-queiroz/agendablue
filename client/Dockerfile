# Use the official lightweight Node.js 14 image
FROM node:lts-alpine AS build

# Set the working directory in the container
WORKDIR /app

# Copy the package.json and package-lock.json files into the container at /app
COPY package*.json ./

# Install dependencies
RUN npm install

# Copy the rest of the application code into the container at /app
COPY . .

# Build the Vue.js application
RUN npm run build

# Use the official Nginx image as the base image
FROM nginx:alpine

# Copy the built Vue.js app from the previous stage into the NGINX web root directory
COPY --from=build /app/dist /usr/share/nginx/html

# Expose port 80 to the Docker host, so you can access the application
EXPOSE 80

# Start Nginx
CMD ["nginx", "-g", "daemon off;"]