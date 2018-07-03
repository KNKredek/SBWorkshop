./publish.sh
docker-compose build
docker-compose run --rm wait_for_services
docker-compose up -d