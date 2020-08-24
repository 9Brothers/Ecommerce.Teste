FROM node:alpine AS build

WORKDIR /app

COPY . .

RUN npm install
RUN npm run prod

FROM nginx

COPY --from=build /app/dist/angular /usr/share/nginx/html