# Use the official lightweight Node image
FROM node:14

# Set the working directory
WORKDIR /app

# Copy package.json and yarn.lock to the working directory
COPY package.json yarn.lock ./

# Install dependencies using yarn
RUN yarn install

# Copy the rest of the application code
COPY . .

# Build the React app
RUN yarn build


# Expose the port
EXPOSE 3000

# Start the React app
CMD ["yarn", "start"]
