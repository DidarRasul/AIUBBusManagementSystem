SELECT
    ba.Id AS AssignmentId,
    ba.BusId,
    ba.RouteId,
    ba.TimeSlotId,
    COUNT(sps.Id) AS PickupCount
FROM BusAssignments ba
LEFT JOIN RouteLocations rl
    ON rl.RouteId = ba.RouteId
LEFT JOIN StudentPickupSelections sps
    ON sps.LocationId = rl.Id
   AND sps.TimeSlotId = ba.TimeSlotId
WHERE ba.Id = 7
GROUP BY
    ba.Id,
    ba.BusId,
    ba.RouteId,
    ba.TimeSlotId;