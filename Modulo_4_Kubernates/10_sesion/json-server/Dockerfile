FROM node:22

WORKDIR /usr/src/app

COPY package*.json ./

# Instala todas las dependencias, incluidas devDependencies
RUN npm install --include=dev

COPY . .

EXPOSE 3000

# Usa npx para resolver tsx localmente
CMD ["npm", "run", "dev"]