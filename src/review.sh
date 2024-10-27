#!/bin/bash

docker build -t service .
docker run -it service