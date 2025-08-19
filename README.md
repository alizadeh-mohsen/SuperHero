# SuperHero

sudo openssl req -x509 -nodes -days 365 -newkey rsa:2048 -keyout api-cert.key -out api-cert.crt -config api-cert.conf -passin pass:Password@1
sudo openssl pkcs12 -export -out api-key.pfx -inkey api-cert.key -in api-cert.crt
sudo openssl req -x509 -nodes -days 365 -newkey rsa:2048 -keyout mvc-cert.key -out mvc-cert.crt -config mvc-cert.conf -passin pass:Password@1
sudo openssl pkcs12 -export -out mvc-key.pfx -inkey mvc-cert.key -in mvc-cert.crt

winget nistall helm.helm
# Add kubernetes-dashboard repository
helm repo add kubernetes-dashboard https://kubernetes.github.io/dashboard/
# Deploy a Helm Release named "kubernetes-dashboard" using the kubernetes-dashboard chart
helm upgrade --install kubernetes-dashboard kubernetes-dashboard/kubernetes-dashboard --create-namespace --namespace kubernetes-dashboard

kubectl apply -f .\admin-user.yaml
kubectl apply .\admin-role.yaml
