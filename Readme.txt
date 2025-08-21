Accessing the Kubernetes Dashboard

helm repo add kubernetes-dashboard https://kubernetes.github.io/dashboard/
helm upgrade --install kubernetes-dashboard kubernetes-dashboard/kubernetes-dashboard --create-namespace --namespace kubernetes-dashboard


kubectl -n kubernetes-dashboard create token admin-user

docker tag <source-image> <registry>/<namespace>/<image-name>:<tag>
docker push <registry>/<namespace>/<image-name>:<tag>

kubectl delete all --all -n <namespace>