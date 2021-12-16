function score(x, y)
	distance = sqrt(x^2 + y^2)
	inner_radius = 1
	middle_radius = 5
	outer_radius = 10
	if distance <= inner_radius
		return 10
	elseif distance <= middle_radius
		return 5
	elseif distance <= outer_radius
		return 1
	else
		return 0
    end
end
