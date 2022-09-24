FROM node:alpine AS my-app-build
WORKDIR /app
COPY . .
RUN npm i && npm run build



FROM nginx:alpine
COPY --from=my-app-build /app/dist/estore-frontend /usr/share/nginx/html
EXPOSE 80